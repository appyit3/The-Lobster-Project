import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/helpers/auth.guard';

const routes: Routes =
    [
        {   
            path: 'login', 
            loadChildren: () => import('../login/login.module').then(m => m.LoginModule)
        },
        {
            path: 'story',
            canLoad:[AuthGuard],
            canActivate: [AuthGuard],
            loadChildren: () => import('../story/story.module').then(m => m.StoryModule)
        },
        {
            path: 'history',
            canLoad:[AuthGuard],
            canActivate: [AuthGuard],
            loadChildren: () => import('../history/history.module').then(m => m.HistoryModule)
        }
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
