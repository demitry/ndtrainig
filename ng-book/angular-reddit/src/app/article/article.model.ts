export class Article {
    title: string;
    link: string;
    votes: number;

    constructor(title: string, link: string, votes?: number) {
        this.title = title;
        this.link = link;
        this.votes = votes || 0;
        // The votes parameter is optional (denoted by the ? at the end of the name) and
        // defaults to zero
    }

    voteUp(): void {
        this.votes += 1;
    }

    voteDown(): void {
        this.votes -= 1;
    }

    // domain() is a utility function that extracts the domain from a URL, which
    // we'll explain shortly
    domain(): string {
        try {
            // e.g. http://foo.com/path/to/bar
            const domainAndPath: string = this.link.split('//')[1];
            // e.g. foo.com/path/to/bar
            return domainAndPath.split('/')[0];
        } catch (err) {
            return null;
        }
    }


/*
Checkout our ArticleComponent component definition now: it’s so short! We’ve moved a
lot of logic out of our component and into our models. The corresponding MVC guideline
here might be Fat Models, Skinny Controllers25. The idea is that we want to move most of
our logic to our models so that our components do the minimum work possible.
http://weblog.jamisbuck.org/2006/10/18/skinny-controller-fat-model
*/
}
