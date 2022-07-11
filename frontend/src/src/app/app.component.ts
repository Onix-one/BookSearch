import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from './models/book';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  readonly ROOT_URL = 'https://localhost:7270/';

  constructor(private http: HttpClient) { }

  books: Observable<Book[]> | undefined;
  resultOfSearch: string | undefined;

  sortedBooks: any | undefined;

  getBooks(input: string) {
    if (input.search.toString() === '') {
      this.books = undefined;
      return;
    }
    this.books = this.http.get<Book[]>(this.ROOT_URL + `api/v1/Books/Get?Search=${input.search}`)
    this.resultOfSearch = input.search.toString();
  }

  sortByAlphabetically() {
    if (typeof (this.books) !== 'undefined') {
      this.books = this.books.pipe(map(data => data.sort(sort)));
    }
    const sort = (a: Book, b: Book) => {
      const titleA = a.title.toLocaleUpperCase();
      const titleB = b.title.toLocaleUpperCase();
      return (titleA < titleB) ? -1 : (titleA > titleB) ? 1 : 0;
    }
  }

  sortByAuthor() {
    if (typeof (this.books) !== 'undefined') {
      this.books = this.books.pipe(map(data => data.sort(sort)));
    }
    const sort = (a: Book, b: Book) => {
      const authorA = this.getAuthors(a).toLocaleUpperCase();
      const authorB = this.getAuthors(b).toLocaleUpperCase();
      return (authorA < authorB) ? -1 : (authorA > authorB) ? 1 : 0;
    }
  }

  getAuthors(book: Book) {
    return book.authors?.map((author) => author.fullName).join(', ') || 'unknown';
  }

  ngOnInit(): void {
  }
}
