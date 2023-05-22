import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MenuAmigosPage } from './menu-amigos.page';

describe('MenuAmigosPage', () => {
  let component: MenuAmigosPage;
  let fixture: ComponentFixture<MenuAmigosPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(MenuAmigosPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
