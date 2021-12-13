import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryComponent } from './select-story/story.component';

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