import { TestBed } from '@angular/core/testing';

import { EventCudService } from './event.cud.service';

describe('Event.CudService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EventCudService = TestBed.get(EventCudService);
    expect(service).toBeTruthy();
  });
});
