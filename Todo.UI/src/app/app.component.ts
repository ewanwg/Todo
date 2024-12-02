import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faXmark, faCheck } from '@fortawesome/free-solid-svg-icons';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FontAwesomeModule, DragDropModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Todo.UI';
  faXmark = faXmark;
  faCheck = faCheck;
  items = [
    { text: 'Item 1', completed: false },
    { text: 'Item 2', completed: false },
    { text: 'Item 3', completed: false },
  ];

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }

  toggleComplete(index: number) {
    this.items[index].completed = !this.items[index].completed;
  }

  deleteItem (index:number) {
    delete this.items[index]
  }
}

