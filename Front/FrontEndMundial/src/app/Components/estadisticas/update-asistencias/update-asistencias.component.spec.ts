import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAsistenciasComponent } from './update-asistencias.component';

describe('UpdateAsistenciasComponent', () => {
  let component: UpdateAsistenciasComponent;
  let fixture: ComponentFixture<UpdateAsistenciasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateAsistenciasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateAsistenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
