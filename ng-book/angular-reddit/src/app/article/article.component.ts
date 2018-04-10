import { 
  Component, 
  OnInit,
  HostBinding  
} from '@angular/core';

import { Article } from './article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  @HostBinding('attr.class') cssClass = 'row';
  article: Article;
  
  constructor() {
    this.article = new Article(
      'Angular 2',
      'http://angular.io',
      10
    ); 
    }

  voteUp(){
    this.article.voteUp();
    //console.log('votes' + this.article.votes);
    return false;
    
    /**
     * clicking on the vote up or vote down links will cause the page to reload instead of
        updating the article list.
        JavaScript, by default, propagates the click event to all the parent components. Because the
        click event is propagated to parents, our browser is trying to follow the empty link, which tells the
        browser to reload.
        To fix that, we need to make the click event handler to return false. This will ensure the browser
        won’t try to refresh the page. Let’s update our code so that each of the functions voteUp() and
        voteDown() return a boolean value of false (tells the browser not to propagate the event upwards):
     */
    
  }

  voteDown(){
    this.article.voteDown();
    //console.log('votes' + this.article.votes);
    return false;
  }

/*
Why do we have a voteUp function in both the model and the component?
The reason we have a voteUp() and a voteDown() on both classes is because each function
does a slightly different thing. The idea is that the voteUp() on the ArticleComponent
relates to the component view, whereas the Article model voteUp() defines what
mutations happen in the model.
That is, it allows the Article class to encapsulate what functionality should happen to a
model when voting happens. In a “real” app, the internals of the Article model would
probably be more complicated, e.g. make an API request to a webserver, and you wouldn’t
want to have that sort of model-specific code in your component controller.
Similarly, in the ArticleComponent we return false; as a way to say “don’t propagate the
event” - this is a view-specific piece of logic and we shouldn’t allow the Article model’s
voteUp() function to have to knowledge about that sort of view-specific API. That is, the
Article model should allow voting apart from the specific view
*/

  ngOnInit() {
  }

}
