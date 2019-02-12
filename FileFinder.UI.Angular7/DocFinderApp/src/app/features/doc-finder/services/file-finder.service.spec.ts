import { TestBed } from '@angular/core/testing';

import { FileFinderService } from './file-finder.service';

describe('FileFinderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileFinderService = TestBed.get(FileFinderService);
    expect(service).toBeTruthy();
  });
});
