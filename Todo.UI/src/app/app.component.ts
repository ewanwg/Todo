import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faXmark, faCheck } from '@fortawesome/free-solid-svg-icons';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    FontAwesomeModule,
    DragDropModule,
    CommonModule,
    FormsModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Todo.UI';
  faXmark = faXmark;
  faCheck = faCheck;
  items = [
    { id: 1, text: 'Item 1', completed: false },
    { id: 2, text: 'Item 2', completed: false },
    { id: 3, text: 'Item 3', completed: false },
  ];
  newText: string = '';

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }

  toggleComplete(id: number) {
    const item = this.items.find((i) => i.id === id);
    if (item) {
      item.completed = !item.completed;
    }
  }

  deleteItem(id: number) {
    this.items = this.items.filter((i) => i.id !== id);
  }

  addItem(): void {
    if (this.newText.trim()) {
      const newItem = {
        id: this.items.length + 1,
        text: this.newText.trim(),
        completed: false,
      };

      this.items.push(newItem);
      this.newText = '';
    }
  }
}

