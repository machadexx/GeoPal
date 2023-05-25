import { Component, OnInit } from '@angular/core';
import { Amigo } from './amigo.model';
import { AmigosServiceService } from './amigos-service.service';

@Component({
  selector: 'app-menu-amigos',
  templateUrl: './menu-amigos.page.html',
  styleUrls: ['./menu-amigos.page.scss'],
})
export class MenuAmigosPage implements OnInit {
  meusAmigos: Amigo[] = [];
  constructor(private amigosService: AmigosServiceService) {}

  ngOnInit() {
    this.meusAmigos = this.amigosService.getAmigos();
  }

}
