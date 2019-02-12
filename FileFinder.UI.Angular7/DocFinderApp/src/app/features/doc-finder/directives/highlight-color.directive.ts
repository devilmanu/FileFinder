import { Directive, ElementRef, Renderer2, AfterViewInit } from '@angular/core';

@Directive({
  selector: '[appHighlightColor]'
})
export class HighlightColorDirective implements AfterViewInit {
  ngAfterViewInit(): void {
    let b = this.el.nativeElement.querySelector('b')
    if(b){
      this.renderer.setStyle(b, "background-color", "blue");
    }
  }

  constructor(private el : ElementRef, private renderer: Renderer2) { 
  }

}
