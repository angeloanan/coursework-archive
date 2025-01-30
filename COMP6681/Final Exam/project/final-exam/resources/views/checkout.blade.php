<x-layout title="Checkout Success">
  <div class="my-8 mx-auto w-full max-w-screen-md">
    <h1 class="text-2xl font-bold">{{ __('cartCheckoutSuccess') }}</h1>

    <div>{{ __('cartCheckoutSuccessDetail') }}</div>

    <div class="mt-4">
      <a href="{{ route('allItem') }}" class="text-blue-900 underline">
        {{ __('cartCheckoutSuccessRedirect') }}
      </a>
    </div>
  </div>
</x-layout>
