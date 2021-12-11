import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryComponent } from './story.component';

const storyRoutes: Routes =
    [
        {
            path: '',
            component: StoryComponent
        }
    ];

@NgModule
    ({
        imports: [RouterModule.forChild(storyRoutes)],
        exports: [RouterModule]
    })
export class StoryRoutingModule { }