![FAV Rocks logo](https://raw.githubusercontent.com/billboga/fav-rocks/master/assets/logo.png)

## What is FAV Rocks?

&ldquo;Favicon Accessible Viewer Rocks&rdquo; is a highly-accessible [favicon](https://en.wikipedia.org/wiki/Favicon) image editor. Leveraging basic HTML elements allows it to function with no [client-side scripting](https://en.wikipedia.org/wiki/Client-side_scripting). Additionally, the application is designed to have a small network footprint. This translates into quick load-times! Its origin coincides with the re-introduction of the [10k Apart challenge](https://a-k-apart.com/) in 2016.

## Will the app. always be under 10k (related to [10k challenge](https://a-k-apart.com/faq#size))?

At the moment, yes. However, since the main page-size is already close to the limit, any new features will cause the existing flow to be questioned. Even adding minute client scripting is difficult with the current setup.

## Why is the app. limited to 16x16 px?

Mainly so the app.-size fits within the confies of [10k](https://a-k-apart.com/faq#size). [DOM](https://en.wikipedia.org/wiki/Document_Object_Model)-count increases as overall grid-size increases. 32x32 is a practical limit to avoid extreme sluggishness partly (*or maybe mostly*) due to applying CSS rules. I do not expect browsers vendors will address the CSS "at-scale" issue any time soon due to its infrequent encounter and perceived impracticality... 😕.

### DOM-count by grid-size

  - "Best" utilizes six-colors per pixel.
  - "Worst" utilizes seven-colors per pixel.

|Width|Height|Best|Worst|
|-----|------|----|-----|
|16   |16    |1,536|1,792 |
|32   |32    |6,144|7,168|
|64   |64    |24,576|28,672|
|128  |128   |98,304|114,688|

## Directive

  1. Follow all rules posted [here](https://a-k-apart.com/faq).