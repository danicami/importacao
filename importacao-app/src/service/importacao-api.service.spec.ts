import { TestBed } from '@angular/core/testing';

import { ImportacaoApiService } from './importacao-api.service';

describe('ImportacaopiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ImportacaoApiService = TestBed.get(ImportacaoApiService);
    expect(service).toBeTruthy();
  });
});
