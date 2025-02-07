import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingTypeSelectComponent } from './training-type-select.component';

describe('TrainingTypeSelectComponent', () => {
  let component: TrainingTypeSelectComponent;
  let fixture: ComponentFixture<TrainingTypeSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingTypeSelectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainingTypeSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
