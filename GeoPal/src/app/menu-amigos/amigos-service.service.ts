import { Injectable } from '@angular/core';
import { Amigo } from './amigo.model';

@Injectable({
  providedIn: 'root'
})
export class AmigosServiceService {
  private amigos: Amigo[] = [
    {
      id: 1,
      nome: 'Seixo Paulo',
      avatar: '../../assets/images/boneco4.png',
      local: 'Aveiro, Portugal'
    },
    {
      id: 2,
      nome: 'Ana Cacho',
      avatar: '../../assets/images/boneco2.png',
      local: 'Aveiro, Portugal'
    }
  ]
  constructor() { }
    getAmigos(){
      return [...this.amigos];
  }
}
