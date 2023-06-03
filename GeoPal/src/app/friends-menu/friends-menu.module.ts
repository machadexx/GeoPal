import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FriendsMenuPageRoutingModule } from './friends-menu-routing.module';

import { FriendsMenuPage } from './friends-menu.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FriendsMenuPageRoutingModule
  ],
  declarations: [FriendsMenuPage]
})
export class FriendsMenuPageModule {}
