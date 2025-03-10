import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { GeneralConfig } from './config/general.config';
import { BACKEND_URL } from './injection-tokens';
import { LoadInterceptor } from './interceptor';

export const appConfig: ApplicationConfig = {
  
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes), 
    provideClientHydration(), 
    provideAnimationsAsync(),
    provideHttpClient(
      withFetch(),
      withInterceptors([LoadInterceptor])
    ),
    { provide: BACKEND_URL, useValue: GeneralConfig.BACKEND_URL },
  ]
};
