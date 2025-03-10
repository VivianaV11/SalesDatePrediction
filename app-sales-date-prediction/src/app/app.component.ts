import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './master-page/footer/footer.component';
import { HeaderComponent } from './master-page/header/header.component';
import { SpinnerComponent } from "./components/shared/spinner/spinner.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FooterComponent, HeaderComponent, SpinnerComponent, SpinnerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Sales-Date-Prediction-app';
}
