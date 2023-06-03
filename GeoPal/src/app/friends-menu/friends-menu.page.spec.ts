import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FriendsMenuPage } from './friends-menu.page';

describe('FriendsMenuPage', () => {
  let component: FriendsMenuPage;
  let fixture: ComponentFixture<FriendsMenuPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(FriendsMenuPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
