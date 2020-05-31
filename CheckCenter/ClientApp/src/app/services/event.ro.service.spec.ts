import { TestBed } from '@angular/core/testing';

import { EventRoService } from './event.ro.service';

describe('Event.RoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EventRoService = TestBed.get(EventRoService);
    expect(service).toBeTruthy();
  });
});
