import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FriendsMenuPage } from './friends-menu.page';

const routes: Routes = [
  {
    path: '',
    component: FriendsMenuPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FriendsMenuPageRoutingModule {}
