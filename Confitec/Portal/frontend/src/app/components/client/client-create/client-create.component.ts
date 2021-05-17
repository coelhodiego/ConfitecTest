import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { ClientService } from '../client.service';
import { Router} from '@angular/router'
import { Client, Escolaridade } from '../client.model';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.component.html',
  styleUrls: ['./client-create.component.css']
})
export class ClientCreateComponent implements OnInit {

  client: Client = {
    nome: '',
    sobrenome: '',
    email: '',
    dataNascimento: undefined,
    escolaridade: undefined
  }

  escolaridades= Escolaridade;

  constructor( private clientService: ClientService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createClient(): void{
    this.clientService.tratarEnum(this.client);
    
    this.clientService.create(this.client).subscribe(() => {
      this.clientService.showMessage('Usuário criado com sucesso')
      this.router.navigate(['/clients'])
    });
  }

  cancel(): void{
    this.router.navigate(['/clients'])
  }
}
