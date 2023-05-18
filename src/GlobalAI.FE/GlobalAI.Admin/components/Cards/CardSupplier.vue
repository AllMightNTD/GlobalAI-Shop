<template>
  <div
    class="bg-white cursor-pointer hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] rounded-xl overflow-hidden"
  >
    <!-- Header Card -->
    <div class="flex justify-between items-center">
      <div
        class="py-[3px] gap-[6px] bg-[#32476d] rounded-br-xl px-[10px] flex items-center"
      >
        <img :src="imgUyTin" class="object-cover w-[20px] h-[20px]" alt="" />
        <span class="text-white font-bold text-[10px]">Uy Tín</span>
      </div>
      <div
        class="py-[3px] gap-[6px] bg-[#53b7ea] rounded-bl-xl px-[10px] flex items-center"
      >
        <img :src="imgXacThuc" class="object-cover w-[20px] h-[20px]" alt="" />
        <span class="text-white font-bold text-[10px]">Xác thực</span>
      </div>
    </div>
    <!-- Content Card -->
    <div class="flex mb-[32px] gap-[15px] px-[5px] items-center">
      <div class="w-[70px] h-[70px] overflow-hidden bg-red-400 rounded-full">
        <img :src="imgSeaGull" alt="img-card" class="object-contain" />
      </div>
      <!-- Content -->
      <div>
        <h3 class="text-[18px] text-[#384059] font-medium">SeaGull</h3>
        <div>
          <div class="flex items-center gap-[5px]">
            <span class="text-[#6C757D]"
              ><span class="text-[14px] font-bold text-[#CC3366]">71</span> sản
              phẩm</span
            >
            <span class="text-[#6C757D]"
              ><span class="text-[14px] font-bold text-[#CC3366]">45.3K</span>
              đã bán</span
            >
          </div>
          <div>
            <span class="text-[#6C757D]"
              ><span class="text-[14px] font-bold text-[#CC3366]">5.9K</span>
              seller bán hàng</span
            >
          </div>
          <span class="text-[#6C757D]"
            ><span class="text-[14px] font-bold text-[#CC3366]">5.5K</span>
            seller theo dõi</span
          >
          <!-- Số sao đánh giá -->
          <div class="flex gap-1 text-[#f8ac59] text-[14px] items-center">
            <div class="flex items-center">
              <font-awesome-icon :icon="['fas', 'star']" />
              <font-awesome-icon :icon="['fas', 'star']" />
              <font-awesome-icon :icon="['fas', 'star']" />
              <font-awesome-icon :icon="['fas', 'star']" />
              <font-awesome-icon :icon="['fas', 'star']" />
            </div>
            4.9/5
          </div>
          <!-- Vị trí -->
          <div class="flex items-center gap-[5px] mt-1">
            <div>
              <font-awesome-icon :icon="['fas', 'location-dot']" />
            </div>
            <span class="text-[14px] font-[450] text-[#6C757D]"
              >Thành phố Hà Nội và 1 kho khác</span
            >
          </div>
        </div>
      </div>
      <div class="flex-1 pr-[10px]">
        <font-awesome-icon
          class="float-right text-[24px]"
          :icon="['fas', 'angle-right']"
        />
      </div>
    </div>
    <!-- Footer Card -->
    <div
      class="flex mt-2 items-center justify-center w-[32%] py-[3px] gap-[5px] px-[10px] bg-[#23c6c8] text-white text-[13px] rounded-tr-md font-bold"
    >
      <svg width="16" height="16" viewBox="0 0 15 12" fill="currentColor">
        <rect y="2" width="6" height="1" rx="0.5" fill="currentColor"></rect>
        <rect
          x="2"
          y="4"
          width="4"
          height="1"
          rx="0.5"
          fill="currentColor"
        ></rect>
        <path
          fill-rule="evenodd"
          clip-rule="evenodd"
          d="M2 1C2 0.447715 2.44772 0 3 0H6C6.55228 0 7 0.447715 7 1V4C7 4.55228 6.55228 5 6 5H4V4H4.49995C4.77609 4 4.99995 3.77614 4.99995 3.5C4.99995 3.22386 4.77609 3 4.49995 3H4H2V1Z"
          fill="currentColor"
        ></path>
        <path
          d="M9.4165 6.87593L8.0485 5.96393L9.67975 4.73993L11.47 6.53018C11.6106 6.67084 11.8014 6.74989 12.0002 6.74993H14.2502V5.24993H12.3107L10.2805 3.21968C10.1529 3.09203 9.98345 3.0147 9.80339 3.00189C9.62332 2.98908 9.44468 3.04164 9.30025 3.14993L7.1485 4.76468C6.95657 4.90859 6.80195 5.09643 6.69762 5.31245C6.5933 5.52846 6.5423 5.76635 6.54891 6.00615C6.55552 6.24594 6.61955 6.48066 6.73562 6.6906C6.8517 6.90053 7.01643 7.07957 7.216 7.21268L8.25025 7.90118V11.2499H9.75025V7.49993C9.75027 7.37649 9.71981 7.25495 9.66159 7.1461C9.60337 7.03724 9.51919 6.94444 9.4165 6.87593Z"
          fill="currentColor"
        ></path>
        <path
          d="M5.25 7.5C4.80499 7.5 4.36998 7.63196 3.99997 7.87919C3.62996 8.12643 3.34157 8.47783 3.17127 8.88896C3.00097 9.3001 2.95642 9.7525 3.04323 10.189C3.13005 10.6254 3.34434 11.0263 3.65901 11.341C3.97368 11.6557 4.37459 11.8699 4.81105 11.9568C5.2475 12.0436 5.6999 11.999 6.11104 11.8287C6.52217 11.6584 6.87357 11.37 7.12081 11C7.36804 10.63 7.5 10.195 7.5 9.75C7.5 9.15326 7.26295 8.58097 6.84099 8.15901C6.41903 7.73705 5.84674 7.5 5.25 7.5ZM5.25 10.5C5.10166 10.5 4.95666 10.456 4.83332 10.3736C4.70999 10.2912 4.61386 10.1741 4.55709 10.037C4.50033 9.89997 4.48547 9.74917 4.51441 9.60368C4.54335 9.4582 4.61478 9.32456 4.71967 9.21967C4.82456 9.11478 4.9582 9.04335 5.10368 9.01441C5.24917 8.98547 5.39997 9.00032 5.53701 9.05709C5.67406 9.11386 5.79119 9.20998 5.8736 9.33332C5.95601 9.45666 6 9.60166 6 9.75C6 9.94891 5.92098 10.1397 5.78033 10.2803C5.63968 10.421 5.44891 10.5 5.25 10.5Z"
          fill="currentColor"
        ></path>
        <path
          d="M12.75 7.5C12.305 7.5 11.87 7.63196 11.5 7.87919C11.13 8.12643 10.8416 8.47783 10.6713 8.88896C10.501 9.3001 10.4564 9.7525 10.5432 10.189C10.6301 10.6254 10.8443 11.0263 11.159 11.341C11.4737 11.6557 11.8746 11.8699 12.311 11.9568C12.7475 12.0436 13.1999 11.999 13.611 11.8287C14.0222 11.6584 14.3736 11.37 14.6208 11C14.868 10.63 15 10.195 15 9.75C15 9.15326 14.7629 8.58097 14.341 8.15901C13.919 7.73705 13.3467 7.5 12.75 7.5ZM12.75 10.5C12.6017 10.5 12.4567 10.456 12.3333 10.3736C12.21 10.2912 12.1139 10.1741 12.0571 10.037C12.0003 9.89997 11.9855 9.74917 12.0144 9.60368C12.0434 9.4582 12.1148 9.32456 12.2197 9.21967C12.3246 9.11478 12.4582 9.04335 12.6037 9.01441C12.7492 8.98547 12.9 9.00032 13.037 9.05709C13.1741 9.11386 13.2912 9.20998 13.3736 9.33332C13.456 9.45666 13.5 9.60166 13.5 9.75C13.5 9.94891 13.421 10.1397 13.2803 10.2803C13.1397 10.421 12.9489 10.5 12.75 10.5Z"
          fill="currentColor"
        ></path>
        <path
          d="M12.0232 0C12.4211 0 12.8026 0.158035 13.0839 0.43934C13.3652 0.720644 13.5232 1.10218 13.5232 1.5C13.5232 1.89782 13.3652 2.27936 13.0839 2.56066C12.8026 2.84196 12.4211 3 12.0232 3C11.1945 3 9 1.5 9 1.5C9 1.5 11.1945 0 12.0232 0Z"
          fill="currentColor"
        ></path>
      </svg>
      <span class="italic">Freeship 80k</span>
    </div>
  </div>
</template>
<script setup>
import imgSeaGull from "~~/assets/img/Home/Sea-gull.jpg";
import imgUyTin from "~~/assets/img/Home/uy-tin.png";
import imgXacThuc from "~~/assets/img/Home/xac-thuc.jpg";
</script>
