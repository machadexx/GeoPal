import { Component, OnInit } from '@angular/core';
import { Amigo } from './friend.model';
import { FriendsServiceService } from './friends-service.service';

@Component({
  selector: 'app-friends-menu',
  templateUrl: './friends-menu.page.html',
  styleUrls: ['./friends-menu.page.scss'],
})
export class FriendsMenuPage implements OnInit {
  meusAmigos: Amigo[] = [];
  constructor(private friendsService: FriendsServiceService) { }

  ngOnInit() {
    this.meusAmigos = this.friendsService.getAmigos();
  }

}
