import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(public auth: AuthService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let user = localStorage.getItem('userId')

        if (user) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`,

                },

            });
        }

        return next.handle(request);
    }
}