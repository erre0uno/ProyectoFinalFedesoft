import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateGoleadoresComponent } from './update-goleadores.component';

describe('UpdateGoleadoresComponent', () => {
  let component: UpdateGoleadoresComponent;
  let fixture: ComponentFixture<UpdateGoleadoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateGoleadoresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateGoleadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
