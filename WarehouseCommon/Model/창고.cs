using Microsoft.EntityFrameworkCore;

namespace 창고Common
{
    public class 창고
    {
        public string 창고코드 { get; set; }
        public string? 창고명 { get; set; }
        public string? 구분 { get; set; } // '창고' 또는 '공장'
        public string? 생산공정명 { get; set; } // 생산 공정 이름 (공장인 경우)
        public string? 외주거래처명 { get; set; } // 연결된 외주 거래처 이름
        public bool? 사용 { get; set; } // 'Yes'로만 되어 있으니, bool 타입을 사용
        public List<창고상품>? 창고상품목록 { get; set; }
    }
    public class 창고상품
    {
        public string 창고상품코드 { get; set; }
        public string? 품목코드 { get; set; }
        public decimal? 입고단가 { get; set; }
        public decimal? 출고단가 { get; set; }
        public string? 창고코드 { get; set; }
        public 창고? 창고 { get; set; }
    }
}