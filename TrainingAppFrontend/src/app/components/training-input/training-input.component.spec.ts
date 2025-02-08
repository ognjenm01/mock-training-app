import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingInputComponent } from './training-input.component';

describe('TrainingInputComponent', () => {
  let component: TrainingInputComponent;
  let fixture: ComponentFixture<TrainingInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainingInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
