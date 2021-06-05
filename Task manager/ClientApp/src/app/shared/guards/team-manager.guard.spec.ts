import { TestBed, async, inject } from '@angular/core/testing';

import { TeamManagerGuard } from './team-manager.guard';

describe('TeamManagerGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TeamManagerGuard]
    });
  });

  it('should ...', inject([TeamManagerGuard], (guard: TeamManagerGuard) => {
    expect(guard).toBeTruthy();
  }));
});
