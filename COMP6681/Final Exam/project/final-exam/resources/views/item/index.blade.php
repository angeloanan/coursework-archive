<x-layout>
  <div class="w-full max-w-screen-lg mx-auto my-8">
    <ol class="grid grid-cols-5 gap-8">
      @foreach ($items->items() as $item)
        <li class="flex flex-col w-full items-center">
          <img src="" alt="" class="h-24 w-24 rounded-full bg-slate-500">
          <span class="text-lg font-medium text-center">{{ $item->item_name }}</span>
          <a href="{{ '/item/' . $item->item_id }}" class="text-blue-900 underline">Detail</a>
        </li>
      @endforeach
    </ol>

    {{-- Page scroll --}}
    <div class="flex gap-3 my-8 w-full justify-center">
      <span>Page:</span>
      @for ($i = 1; $i <= $items->total() / $items->perPage(); $i++)
        <a href="{{ $items->url($i) }}"
          class="{{ $items->currentPage() == $i ? 'font-bold' : 'text-blue-900 underline' }}">{{ $i }}</a>
      @endfor
    </div>
  </div>
</x-layout>
