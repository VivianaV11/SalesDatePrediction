import { Component, OnInit } from '@angular/core';
import { SpinnerService } from '../../../services';
import { Subject } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  standalone: true,
  imports: [CommonModule, MatProgressSpinnerModule],
  selector: 'app-spinner',
  templateUrl: './templates/spinner.component.html',
  styleUrl: './styles/spinner.component.scss'
})
export class SpinnerComponent implements OnInit {
  public isloading$ = new Subject<boolean>();;

  constructor(
    private readonly spinnerService: SpinnerService
  ) { }

  ngOnInit(): void {
    this.isloading$ = this.spinnerService.isLoading$;
  }
}
