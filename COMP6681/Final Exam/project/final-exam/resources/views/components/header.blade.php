<header class="w-full">
  <div class="bg-green-300 flex py-2 w-full">
    <div class="w-full flex justify-center items-center py-2">
      <a href="{{ session()->has('user_id') ? '/item' : '/' }}" class="text-2xl font-bold">
        Amazing E-Grocery
      </a>
    </div>

    {{-- Login / Register Buton  --}}
    <div class="gap-6 flex self-end mx-4 font-medium">
      @if (!auth()->check())
        <a class="rounded py-2 px-3 bg-yellow-300 text-yellow-900" href="{{ route('register') }}">{{ __('register') }}</a>
        <a class="rounded py-2 px-3 bg-yellow-300 text-yellow-900" href="{{ route('login') }}">{{ __('login') }}</a>
      @else
        <a class="rounded py-2 px-3 bg-yellow-300 text-yellow-900" href="{{ route('logout') }}">{{ __('logout') }}</a>
      @endif
    </div>

  </div>

  {{-- Auth only navbar --}}
  @if (auth()->check())
    <div class="w-full bg-yellow-300 py-2">
      <div class="mx-auto flex gap-8 w-min">
        <a class="font-medium" href="{{ route('allItem') }}">{{ __('pageHome') }}</a>
        <a class="font-medium" href="{{ route('cart') }}">{{ __('pageCart') }}</a>
        <a class="font-medium" href="{{ route('profile') }}">{{ __('pageProfile') }}</a>

        @if (auth()->user()->role->role_name == 'admin')
          <a class="font-medium shrink-0" href="{{ route('admin') }}">{{ __('pageAdmin') }}</a>
        @endif
      </div>
    </div>
  @endif
</header>
