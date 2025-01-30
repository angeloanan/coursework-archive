<x-layout>
  <div class="grid grid-cols-3 w-full max-w-screen-lg mx-auto my-8">
    {{-- Image and Such --}}
    <aside class="space-y-4 flex flex-col items-center">
      <h1 class="text-xl font-medium underline w-full text-center">{{ $item->item_name }}</h1>
      <img src="" alt="" class="h-64 w-64 rounded-full bg-slate-800">
    </aside>

    {{-- Details --}}
    <div class="col-span-2">
      <div class="text-lg font-medium tabular-nums">
        {{ __('productPrice') }}: Rp. {{ number_format($item->price, 0, ',', '.') }}
      </div>

      <div>{{ $item->item_desc }}</div>

      <div class="w-full flex justify-end">
        <a href="/item/{{ $item->item_id }}/buy"
          class="px-6 py-2 bg-yellow-300 text-yellow-900 rounded">{{ __('productBuy') }}</a>
      </div>
    </div>
  </div>
</x-layout>
