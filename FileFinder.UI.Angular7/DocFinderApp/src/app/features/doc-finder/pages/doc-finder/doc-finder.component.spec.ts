import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocFinderComponent } from './doc-finder.component';

describe('DocFinderComponent', () => {
  let component: DocFinderComponent;
  let fixture: ComponentFixture<DocFinderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocFinderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocFinderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
