import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MenuAmigosPageRoutingModule } from './menu-amigos-routing.module';

import { MenuAmigosPage } from './menu-amigos.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MenuAmigosPageRoutingModule
  ],
  declarations: [MenuAmigosPage]
})
export class MenuAmigosPageModule {}
