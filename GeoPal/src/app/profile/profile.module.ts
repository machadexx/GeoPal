import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProfilePageRoutingModule } from './profile-routing.module';

import { ProfilePage } from './profile.page';

import { MapaProfileComponent } from '../mapa-profile/mapa-profile.component';

import { MapaModule } from '../mapa/mapa.module';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProfilePageRoutingModule,
    MapaModule
  ],
  declarations: [ProfilePage, MapaProfileComponent]
})
export class ProfilePageModule {}
