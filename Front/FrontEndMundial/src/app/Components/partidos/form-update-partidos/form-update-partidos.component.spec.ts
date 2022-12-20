import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUpdatePartidosComponent } from './form-update-partidos.component';

describe('FormUpdatePartidosComponent', () => {
  let component: FormUpdatePartidosComponent;
  let fixture: ComponentFixture<FormUpdatePartidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUpdatePartidosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormUpdatePartidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
