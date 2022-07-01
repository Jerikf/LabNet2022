import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreteCategorieComponent } from './crete-categorie.component';

describe('CreteCategorieComponent', () => {
  let component: CreteCategorieComponent;
  let fixture: ComponentFixture<CreteCategorieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreteCategorieComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreteCategorieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
