<x-layout title="Register">
  <div class="max-w-prose w-full mx-auto my-4">
    <h1 class="text-2xl font-semibold">{{ __('login') }}</h1>

    @if ($errors->any())
      <div class="w-full bg-red-200 rounded-lg p-4 my-4">
        <span class="text-red-900 font-medium text-lg">Something went wrong!</span>
        <ul class="list-disc">
          @foreach ($errors->all() as $error)
            <li class="text-red-900">{{ $error }}</li>
          @endforeach
        </ul>
      </div>
    @endif

    <form method="POST" action="/login" enctype="multipart/form-data" class="grid grid-cols-2 my-4 gap-2">
      {{ csrf_field() }}

      <label class="flex flex-col gap-2">
        {{ __('email') }}
        <input type="email" name="email" required>
      </label>


      <label class="flex flex-col gap-2 shrink-0">
        {{ __('password') }}
        <input type="password" name="password" minlength="8" autocomplete="on" required>
      </label>

      <button class="px-3 py-2 bg-yellow-300 text-yellow-900 rounded text-lg">{{ __('login') }} &rarr;</button>
    </form>

    <div class="my-4">
      <a href={{ route('register') }} class="text-blue-800 underline">
        {{ __('registerRedirect') }}
      </a>
    </div>

  </div>
</x-layout>
