import { Component, OnInit } from '@angular/core';
import { RegistoService } from './registo.service';
import { ToastController } from '@ionic/angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {
  registo: any = {};

  constructor(
    private registoService: RegistoService,
    private toastController: ToastController,
    private router: Router
  ) {}

  async registrar(registo: any): Promise<void> {
    try {
      const response = await this.registoService.registrar(registo).toPromise();
      console.log('Registo realizado com sucesso', response);

      const toast = await this.toastController.create({
        message: 'Registo realizado com sucesso',
        duration: 2000, // duração em milissegundos
        position: 'bottom' // posição do Toast na tela
      });
      toast.present();

      this.router.navigate(['/register/register-success']);

    } catch (error) {
      console.error('Erro ao registrar', error);
      const errorMessage = (error as any).error;
      if (errorMessage === 'O email já está em uso.') {
        const toast = await this.toastController.create({
          message: 'O email já está em uso.',
          duration: 2000,
          position: 'bottom'
        });
        toast.present();
      } else {
        const toast = await this.toastController.create({
          message: 'Erro ao registrar',
          duration: 2000,
          position: 'bottom'
        });
        toast.present();
      }
    }
  }

  ngOnInit() {}
}
