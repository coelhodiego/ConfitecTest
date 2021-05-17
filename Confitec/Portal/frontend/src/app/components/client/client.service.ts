import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar} from '@angular/material/snack-bar'
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Client, Escolaridade } from './client.model';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl = 'http://localhost:54900/Cliente/';

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string, isError: boolean = false): void{
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ?['msg-error'] : ['msg-success']
    })
  }

  create(client: Client): Observable<boolean> {
    return this.http.post<boolean>(this.baseUrl + 'Add', client).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  read(): Observable<Client[]>{
    return this.http.get<Client[]>(this.baseUrl + "GetAll").pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  readById(id: string): Observable<Client> {
    const url = `${this.baseUrl}GetById?id=${id}`;
    return this.http.get<Client>(url).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  update(client: Client): Observable<boolean> {
    const url = `${this.baseUrl}Update`;
    return this.http.put<boolean>(url, client).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  delete(client: Client): Observable<boolean> {
    const url = `${this.baseUrl}Delete`;
    return this.http.request<boolean>('delete', url, {body: client}).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }
  
  errorHandler(e: any): Observable<any> {
    this.showMessage('Ocorreu um erro!', true);
    return EMPTY;
  }

  tratarEnum(client: Client): void{
    if(client.escolaridade?.toString() == "1"){
      client.escolaridade = Escolaridade.Infantil
      return;
    }

    if(client.escolaridade?.toString() == "2"){
      client.escolaridade = Escolaridade.Fundamental
      return;
    }

    if(client.escolaridade?.toString() == "3"){
      client.escolaridade = Escolaridade.Medio
      return;
    }

    if(client.escolaridade?.toString() == "4"){
      client.escolaridade = Escolaridade.Superior
      return;
    }
  }
}
