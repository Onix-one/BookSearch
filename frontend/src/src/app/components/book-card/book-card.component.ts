import { Component, OnInit, Input } from '@angular/core';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.scss']
})
export class BookCardComponent implements OnInit {

  constructor() { }


  @Input() book!: Book;

  buttonLikeColor: string = 'primary';

  like() {
    if (this.buttonLikeColor === 'primary') {
      this.buttonLikeColor = 'warn'
    }
    else {
      this.buttonLikeColor = 'primary'
    }
  }

  getAuthors() {
    return this.book.authors?.map((author)=> author.fullName).join(', ') || 'unknown';
  }

  ngOnInit(): void {
  }

}
