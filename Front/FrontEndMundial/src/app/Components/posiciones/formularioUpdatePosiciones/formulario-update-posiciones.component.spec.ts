import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioUpdatePosicionesComponent } from './formulario-update-posiciones.component';

describe('BotonesComponent', () => {
  let component: FormularioUpdatePosicionesComponent;
  let fixture: ComponentFixture<FormularioUpdatePosicionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioUpdatePosicionesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioUpdatePosicionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
