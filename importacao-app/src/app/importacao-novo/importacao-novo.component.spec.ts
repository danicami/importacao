import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportacaoNovoComponent } from './importacao-novo.component';

describe('ImportacaoNovoComponent', () => {
  let component: ImportacaoNovoComponent;
  let fixture: ComponentFixture<ImportacaoNovoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImportacaoNovoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportacaoNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
