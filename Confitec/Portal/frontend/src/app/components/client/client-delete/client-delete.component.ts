import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client, Escolaridade } from '../client.model';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-delete',
  templateUrl: './client-delete.component.html',
  styleUrls: ['./client-delete.component.css']
})
export class ClientDeleteComponent implements OnInit {

  client: Client = {
    nome: '',
    sobrenome: '',
    email: '',
    dataNascimento: undefined,
    escolaridade: undefined
  };
  loaded = false;
  escolaridades= Escolaridade;

  constructor(private clientService: ClientService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')?.toString();

    if(id != undefined)
      this.clientService.readById(id).subscribe(client => {
        this.client = client;
        this.loaded = true;
        console.log(this.client);
      });
  }

  deleteClient(): void {
    debugger;
    this.clientService.tratarEnum(this.client);
    
    this.clientService.delete(this.client).subscribe(response => {
      debugger;
      if(response == true){
        this.clientService.showMessage('Cliente excluído com sucesso');
        this.router.navigate(['clients']);
      }
      console.log(response);
    })
  }

  cancel(): void {
    this.router.navigate(['clients']);
  }
}
