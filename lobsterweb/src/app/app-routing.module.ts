import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes =
    [
        {
            path: 'story',
            loadChildren: () => import('../story/story.module').then(m => m.StoryModule)
        },
        {
            path: 'history',
            loadChildren: () => import('../history/history.module').then(m => m.HistoryModule)
        },
        {
          path: '**',   //load default component
          loadChildren: () => import('../story/story.module').then(m => m.StoryModule),
          pathMatch: 'full'
        }
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
