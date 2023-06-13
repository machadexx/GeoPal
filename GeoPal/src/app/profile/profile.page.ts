import { Component, OnInit } from '@angular/core';
import { ProfileServiceService } from './profile-service.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AlertController } from '@ionic/angular';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {
  userProfile: any;

  constructor(private profileService: ProfileServiceService, private router: Router, private http: HttpClient, private alertController: AlertController) {}


  sair() {
    localStorage.removeItem('email');
    localStorage.removeItem('password');

    this.router.navigateByUrl('/home');
  }

  get localizacao(): string {
    if (this.userProfile && this.userProfile.Coordenadas_latitude === null && this.userProfile.Coordenadas_longitude === null) {
      return 'Sem dados.';
    } else {
      return `${this.userProfile.Coordenadas_latitude}, ${this.userProfile.Coordenadas_longitude}`;
    }
  }

  async eliminarConta() {
    const userId = this.userProfile.UtilizadorID;
    const apiUrl = `http://localhost/API_WebGeo/api/delete/${userId}`;

    // Cria o alerta de confirmação
    const confirmarExclusao = await this.alertController.create({
      header: 'Confirmar Exclusão',
      message: 'Tem certeza de que deseja excluir sua conta?',
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            // O usuário cancelou a exclusão, não faz nada
            // Ou você pode exibir uma mensagem informando que a conta não foi excluída
            console.log('A exclusão da conta foi cancelada.');
          }
        },
        {
          text: 'OK',
          handler: () => {
            // O usuário confirmou a exclusão, envia a solicitação DELETE para a API
            this.http.delete(apiUrl).subscribe(
              () => {
                // A conta do utilizador foi eliminada com sucesso
                // Faça qualquer ação necessária, como redirecionar para a página de login
                console.log('Sua conta foi excluída com sucesso!');
                // Redirecionar para a página inicial
                window.location.href = "/home";
              },
              (error) => {
                console.error(error);
                // Trate o erro adequadamente, exibindo uma mensagem de erro ao utilizador, por exemplo
                console.log('Ocorreu um erro ao excluir a conta. Por favor, tente novamente mais tarde.');
              }
            );
          }
        }
      ]
    });

    // Exibe o alerta de confirmação
    await confirmarExclusao.present();
  }


  ngOnInit() {
    this.loadUserProfile();
  }

  async loadUserProfile() {
    try {
      this.userProfile = await this.profileService.getUserProfile();
    } catch (error) {
      console.error(error);

    }
  }
}
