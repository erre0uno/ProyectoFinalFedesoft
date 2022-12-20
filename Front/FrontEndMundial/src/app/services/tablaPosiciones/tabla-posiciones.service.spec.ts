import { TestBed } from '@angular/core/testing';

import { TablaPosicionesService } from './tabla-posiciones.service';

describe('TablaPosicionesService', () => {
  let service: TablaPosicionesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TablaPosicionesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
