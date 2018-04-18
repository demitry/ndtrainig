function **skuValidator**(control: FormControl): { [s: string]: boolean } {
if (!control.value.match(/^123/)) {
return {invalidSku: true};
}
}
there’s one small problem: we
already have a validator on sku. How can we add multiple validators to a single field?
For that, we use Validators.compose:

Assigning the Validator to the FormControl

constructor(fb: FormBuilder) {
this.myForm = fb.group({
    'sku': ['', Validators.**compose**([
    Validators.required, **skuValidator**])]
});
<div *ngIf="sku.hasError('invalidSku')"
    class="ui error message">SKU must begin with <span>123</span></div>
