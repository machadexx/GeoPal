import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterPage } from './register.page';
import { RegisterSuccessPage } from './register-success/register-success.page';

const routes: Routes = [
  {
    path: '',
    component: RegisterPage
  },
  {
    path: 'register-success',
    component: RegisterSuccessPage
  },
  {
    path: 'register-success',
    loadChildren: () => import('./register-success/register-success.module').then( m => m.RegisterSuccessPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RegisterPageRoutingModule {}
