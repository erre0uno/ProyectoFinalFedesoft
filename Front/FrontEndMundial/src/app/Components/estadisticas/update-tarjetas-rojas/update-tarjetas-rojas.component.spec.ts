import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTarjetasRojasComponent } from './update-tarjetas-rojas.component';

describe('UpdateTarjetasRojasComponent', () => {
  let component: UpdateTarjetasRojasComponent;
  let fixture: ComponentFixture<UpdateTarjetasRojasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateTarjetasRojasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateTarjetasRojasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
