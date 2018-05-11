# Firefox Dark New Tab
Easily change Firefox Quantum's new tab to a dark theme.

## How do I do this manually?
Simply put this .css code into \[YourFireFoxInstallFolder\]\chrome\userContent.css
(Yes, you put the code for FIREFOX into a folder called CHROME. Weird.)
~~~~
@-moz-document url(about:newtab) {
    .activity-stream {
        background-color: #333333 !important;
    }
    .top-sites-list .top-site-outer > a {
        color: #dddddd !important;
    }
    .tile {
      filter: grayscale(42%) !important;
      opacity: .9 !important;
    }
    @media (min-width: 1280px) {
      .activity-stream main {
        width: 989px !important;
      }
    }
    .tabbrowser-tabbox { 
      background-color: #000000 !important; 
    } 
}
~~~~

And then simply restart Firefox.
