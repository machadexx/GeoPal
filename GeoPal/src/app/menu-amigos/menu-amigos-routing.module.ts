import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MenuAmigosPage } from './menu-amigos.page';

const routes: Routes = [
  {
    path: '',
    component: MenuAmigosPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MenuAmigosPageRoutingModule {}
