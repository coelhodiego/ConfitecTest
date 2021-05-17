import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client, Escolaridade } from '../client.model';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-update',
  templateUrl: './client-update.component.html',
  styleUrls: ['./client-update.component.css']
})
export class ClientUpdateComponent implements OnInit {

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

  updateClient(): void {
    debugger;
    this.clientService.tratarEnum(this.client);
    
    this.clientService.update(this.client).subscribe(response => {
      debugger;
      if(response == true){
        this.clientService.showMessage('Cliente atualizado com sucesso');
        this.router.navigate(['clients']);
      }
      console.log(response);
    })
  }

  cancel(): void {
    this.router.navigate(['clients']);
  }
}
